// import { ref, computed, onMounted } from 'vue'
// import { storeToRefs } from 'pinia'
// import { useDebounceFn } from '@vueuse/core'

export function usePagedList2(store, pagerKey, listKey, fetchAction) 
{
	// refs to store state
	const { [pagerKey]: listPagerRef, [listKey]: itemsListRef } = storeToRefs(store)

	const showAdvSearch = ref(false)
	const activeItem = ref(null)
	const currentPage = ref(0)
	const searchInput = ref(null)

	// computed helper
	const activeListItemId = computed(() =>
		activeItem.value ? activeItem.value[listPagerRef.value.Search.detailKeyName || 'id'] : 0
	)

	const isActiveItem = id => activeListItemId.value === id
	const listHasRecords = () => itemsListRef.value.length > 0

	// ---------------------------------------------
	// Refresh / set active item
	// ---------------------------------------------
	const setActiveItem = () => {
		activeItem.value = itemsListRef.value[listPagerRef.value.offset()]
		currentPage.value = listPagerRef.value.currentPage()
	}

	const refreshList = async (newRecord = 1, forceRefresh = false) => 
	{
		listPagerRef.value.CurrentRecord = newRecord

		if (listPagerRef.value.currentPage() !== currentPage.value || forceRefresh) {
			await fetchList()
		} else {
			setActiveItem()
		}
	}

	const fetchList = async () => 
	{
		await store[fetchAction](listPagerRef.value)
		currentPage.value = listPagerRef.value.currentPage()
		setActiveItem()
	}

	// ---------------------------------------------
	// Keyboard navigation
	// ---------------------------------------------
	const keys = e => 
	{
		if (!listPagerRef.value) return

		if (e.code === 'ArrowUp') 		 listPagerRef.value.goToPrevious()
		else if (e.code === 'ArrowDown') listPagerRef.value.goToNext()
		else if (e.code === 'PageDown')  listPagerRef.value.goToPreviousPage()
		else if (e.code === 'PageUp') 	 listPagerRef.value.goToNextPage()
		else if (e.code === 'Home') 	 searchInput.value?.focusInput()

		e.preventDefault()
	}

	// ---------------------------------------------
	// Lifecycle
	// ---------------------------------------------
	onMounted(() => {
		refreshList(1, true)
		searchInput.value?.focusInput()
	})

	// ---------------------------------------------
	// Watches
	// ---------------------------------------------
	watch(
		() => listPagerRef.value.CurrentRecord,
		(newVal, oldVal) => {
			if (newVal !== oldVal) refreshList(newVal)
		}
	)

	watch(
		() => listPagerRef.value.PageSize,
		(newVal, oldVal) => {
			if (newVal !== oldVal) refreshList(1, true)
		}
	)

	watch(
		() => listPagerRef.value.Search.Filter,
		(newVal, oldVal) => {
			if (newVal === oldVal || newVal.slice(-1) === ',' || newVal.slice(-1) === ' ') return

			useDebounceFn(() => refreshList(1, true), 1000)()
		}
	)

	return {
		listPager: listPagerRef,
		itemsList: itemsListRef,
		activeItem,
		showAdvSearch,
		searchInput,
		isActiveItem,
		listHasRecords,
		refreshList,
		keys
	}
}
