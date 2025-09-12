// usePagedList.js

import { SearchForAccount } from "../models/PagerModel"

//import { ref, computed, onMounted, watch } from 'vue'
//import { useLocalStorage, useDebounceFn } from '@vueuse/core'

export function usePagedList(
{
    getPagedItems,              // function to fetch items (store action)
    itemsList,                  // ref to store list
    listPager,                  // ref to PagerModel in store
    activeDetailId,             // ref to active detail id in store
    persistSearch,              // ref<boolean> from app store
    detailKeyName,              // e.g. "AccountId"
    pageSizeDefaultName,        // localStorage key for page size
    searchFilterDefaultName,    // localStorage key for search filter
    createSearchModel,          // factory function: () => new SearchForAccount() or new SearchModel()
}) 
{
    const currentPage   = ref(0)
    const activeItem    = ref(null)
    const showAdvSearch = ref(false)
    const searchInput   = ref(null)

    // Local storage defaults
    const listPageSizeDefault = useLocalStorage(pageSizeDefaultName, 15)
    const searchFilterDefault = useLocalStorage(searchFilterDefaultName, '')

    // ✅ Defensive initialization
    if (!listPager.value || !listPager.value.Search) 
        listPager.value = new PagerModel(createSearchModel())

    if (listPager.value.Search.Filter === undefined) 
        listPager.value.Search.Filter = persistSearch?.value ? searchFilterDefault.value : ''

    if (!listPager.value.PageSize) 
        listPager.value.PageSize = listPageSizeDefault.value

    console.log('Use listPager.value.Search:', listPager.value.Search , listPager.value.Search instanceof SearchForAccount )

    // --- Core methods / computeds ---
    const activeListItemId = computed(() =>
        activeItem.value ? activeItem.value[detailKeyName] : 0
    )

    const isActiveItem = (id) => activeListItemId.value === id
    const listHasRecords = () => itemsList.value.length > 0
    const refreshItem = (offset) => refreshList(listPager.value.currentFirst() + offset)

    const setActiveItem = () => 
    {
        activeItem.value = itemsList.value[listPager.value.offset()]
        currentPage.value = listPager.value.currentPage()
        activeDetailId.value = activeListItemId.value
    }

    const refreshList = (newRecord, forceRefresh) => 
    {
        listPager.value.CurrentRecord = newRecord
        if (listPager.value.currentPage() !== currentPage.value || forceRefresh) 
        {
            getListData()
        } 
        else 
        {
            setActiveItem()
        }
    }

    const getListData = async (refresh) => 
    {
        console.log('getListData')

        if (refresh) 
        {
            const newPager = new PagerModel(createSearchModel())
            newPager.Search.Filter = listPager.value.Search.Filter
            newPager.PageSize = listPager.value.PageSize
            listPager.value = newPager
        }

        await getPagedItems(listPager.value)

        currentPage.value = listPager.value.currentPage()
        activeItem.value = itemsList.value[listPager.value.offset()]
        listPageSizeDefault.value = listPager.value.PageSize

        setActiveItem()
    }

    // Watch search filter with debounce
    watch( () => listPager.value.Search.Filter, (newVal, oldVal) => 
    {
        if (newVal === oldVal || newVal.slice(-1) === ',' || newVal.slice(-1) === ' ' )
            return

        useDebounceFn(() => refreshList(1, true), 1000)()

        if (persistSearch?.value) {
            searchFilterDefault.value = newVal
        }
    })

    onMounted(() => 
    {
        refreshList(1, true)
        searchInput.value?.focusInput()
    })

    return {
        listPager,
        itemsList,
        showAdvSearch,
        searchInput,
        isActiveItem,
        listHasRecords,
        refreshItem,
        getListData,
    }
}
