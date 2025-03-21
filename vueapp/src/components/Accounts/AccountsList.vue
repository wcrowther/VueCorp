
<script setup>

    // Setup  ==========================================================================================

    const accountsStore                         = useAccountsStore()
    const appStore                              = useAppStore()

    const { getPagedAccounts }                  = accountsStore

    const { accountsList:    itemsList,        
            accountsPager:   listPager,       
            detailAccountId: activeDetailId }   = storeToRefs(accountsStore)
    const { sideBarHidden, persistSearch }      = storeToRefs(appStore)  

    // Page Specific  =================================================================================

    const { width: windowWidth }    = useWindowSize()
    
    watch(() => windowWidth.value, (newVal, oldVal) => 
    { 
        if(newVal < 480 && oldVal >= 480) { sideBarHidden.value = true }
    });

    // ===============================================================================================
    // ItemsList Begin
    // ===============================================================================================

    const detailKeyName                 = 'AccountId'
    const pageSizeDefaultName           = 'accountsPageSizeDefault'
    const searchFilterDefaultName       = 'accountsSearchFilterDefault'        
    const currentPage                   = ref(0)
    const activeItem                    = ref(null)
    const showAdvSearch                 = ref(false)

    const searchInput                   = ref(null) // used to call method searchInput.value.focusInput()   
                                                    // on a component. useTemplateRef('searchInput') in Vue 3.5+

    const listPageSizeDefault           = useLocalStorage(pageSizeDefaultName, 15)
    listPager.value.PageSize            = listPageSizeDefault

    const searchFilterDefault           = persistSearch.value ? useLocalStorage(searchFilterDefaultName, '') : ''
    listPager.value.Search              = new SearchForAccount(searchFilterDefault)  

    // Methods / Computeds ===========================================================================

    const activeListItemId      = computed(() => activeItem.value ? activeItem.value[detailKeyName] : 0) 

    const isActiveItem          = (id)      => activeListItemId.value === id
    const listHasRecords        = ()        => itemsList.value.length  > 0
    const refreshItem           = (offset)  => refreshList(listPager.value.currentFirst() + offset)

    const setActiveItem         = () =>
    {   
        activeItem.value        = itemsList.value[listPager.value.offset()]
        currentPage.value       = listPager.value.currentPage()
        activeDetailId.value    = activeListItemId.value
    }

    const refreshList           = (newRecord, forceRefresh) =>
    {
        listPager.value.CurrentRecord = newRecord
            
        if ((listPager.value.currentPage() !== currentPage.value) || forceRefresh)
           getListData()
        else 
           setActiveItem()
    }

    const getListData = async (refresh) =>
    {
        if(refresh)
        {
            let newPager                = new PagerModel()
            newPager.Search.Filter      = listPager.value.Search.Filter
            newPager.PageSize           = listPager.value.PageSize
            listPager.value             = newPager
        }

        await getPagedAccounts(listPager.value)

        currentPage.value               = listPager.value.currentPage()
        activeItem.value                = itemsList.value[listPager.value.offset()]
        listPageSizeDefault.value       = listPager.value.PageSize

        setActiveItem()
    } 

    // Listeners   ====================================================================================

    const keys = function (e)   
    {
        // console.log(e.code);    
        if      (e.code === 'ArrowUp')    { listPager.value.goToPrevious();     e.preventDefault();}
        else if (e.code === 'ArrowDown')  { listPager.value.goToNext();         e.preventDefault();}
        else if (e.code === 'PageDown')   { listPager.value.goToPreviousPage(); e.preventDefault();}
        else if (e.code === 'PageUp')     { listPager.value.goToNextPage();     e.preventDefault();} 
        else if (e.code === 'Home')       { searchInput.value.focusInput();     e.preventDefault();} 
    }  

    // 'Ctrl+S' to Save is in AccountsDetail control

    // ALT: else if (e.code === 'Home') { listPager.value.goToFirstPage(); e.preventDefault();}
    // ALT: else if (e.code === 'End')  { listPager.value.goToLastPage();  e.preventDefault();}
   
	KeyboardListeners(keys);

    // Lifecycle & Watches  ==========================================================================

    onMounted(() =>    
    {        
        refreshList(1, true)
        searchInput.value.focusInput()
    })

    watch(() => listPager.value.CurrentRecord, (newVal, oldVal) => 
    {
        if(newVal === oldVal) return
        refreshList(newVal)
    })

    watch(() => listPager.value.Search.Filter, (newVal, oldVal) => 
    {
        if(newVal === oldVal || newVal.slice(-1) == ',' || newVal.slice(-1) == ' ')
            return 

        useDebounceFn(() => refreshList(1, true), 1000)()
        searchFilterDefault.value = newVal
    })

    // ===============================================================================================

</script>

<template>
    <div id="accountsList">

        <div class="px-5 flex flex-wrap justify-between items-center border-t border-r border-slate-300
            bg-gradient-side shadow-[0_10px_30px_-5px_rgb(0,0,0,0.4)] xxs:shadow-none">
            
            <div class="flex gap-x-1 pt-5 w-full">
                <SearchInput ref="searchInput" v-model="listPager.Search.Filter" v-model:showAdvSearch="showAdvSearch" />
            </div>

            <div v-if="listPager.Search.StateProvinceFilter.length > 0" 
                class="ml-5 text-sm mt-2 italic">
                Filters: {{ listPager.Search.StateProvinceFilter }}
            </div>

            <div class="w-full flex justify-between items-center select-none my-3">
                <ListPager class="mr-2" id='listPager' v-bind:pager="listPager" />
                <span class="text-sm xs:hidden md:inline whitespace-nowrap">Total: {{listPager.TotalCount || 0 }}</span>
            </div>

            <MobilePagerPrevNext :pager="listPager" />

            <HelpBox class="mb-3">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. 
                Voluptates accusamus repudiandae quam officiis temporibus dicta ipsa iure? 
            </HelpBox>

            <InfoBox class="py-3 mb-5">
                Search for Accounts that start with this text or are equal to the AccountId. Add multiple conditions separated by a comma.
            </InfoBox>

        </div>

        <table class="w-full bg-gray-100 select-none xs:shadow-none
            shadow-[0_10px_30px_-5px_rgb(0,0,0,0.4)]" id="accounts-list-table">

            <thead class="text-left bg-gradient-table-head border-t border-gray-300 ">
                <th class="w-6 sm:w-8 py-5 bg-[#ddd]"></th>
                <th class="hidden md:table-cell pr-4 select-none bg-[#ddd]">Id</th>
                <th class="pr-4 min-w-[100px]">Account</th>
            </thead>

            <tbody v-if="listHasRecords()" >
                <tr v-for="(a, index) in itemsList" 
                    class="border-y bg-gradient-side2 border-gray-300"
                    :class="{ 'active-row' : isActiveItem(a.AccountId) }"
                    @click="refreshItem(index)" :key="a.AccountId">

                    <td class="w-6 p-0 sm:w-8 select-none bg-white">
                        <div v-if="isActiveItem(a.AccountId)" class="active-arrow" >&nbsp;</div>
                    </td>

                    <td class="hidden md:table-cell pr-4 py-1 text-sm">
                        {{ a.AccountId }}
                    </td>

                    <td class="pr-4 py-1 h-8 max-w-[200px] break-words text-sm"
                        :title="'Account Id: ' + a.AccountId" >{{ a.AccountName }}</td>
                </tr>
            </tbody>

            <tbody v-else class="h-20 text-center font-bold">
                <tr>
                    <td colspan="3" class="px-4 py-1">No Accounts found</td>
                </tr>
            </tbody>

            <tfoot>
                <td colspan="3" class="h-8 bg-[#e9e9e9]">&nbsp;</td>
            </tfoot>

        </table>

        <AccountAdvSearch v-model:show="showAdvSearch" v-model:listPager="listPager"
            @getListData="getListData"></AccountAdvSearch>

    </div>

</template>

<style lang="postcss" scoped>
    .active-row     { @apply bg-gradient-white }
    .active-arrow   { @apply w-0 h-0 border-x-[8px] border-y-[6px] border-transparent border-l-[#91a5bd] relative left-3 }
    .reset-x        { @apply text-black hover:text-color-mid-gray }
</style> 

<!--
<div class="rounded-full bg-[#b8d7ed] fixed xs:hidden h-10 w-10 z-[100] 
    opacity-80 bottom-1 right-1 flex justify-center items-center" @click="listPager.goToNext()">
    <IconSymbol class="select-none" width="18px" color="white" icon="mdi:arrow-down-thick" />
</div> 
-->