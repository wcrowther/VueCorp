
<script setup>

    // Page Specific  =================================================================================

    const { width: windowWidth }    = useWindowSize()
    const appStore                  = useAppStore()
    const { sideBarHidden, persistSearch }           
                                    = storeToRefs(appStore)    
    
    watch(() => windowWidth.value, (newVal, oldVal) => 
    { 
        if(newVal < 480 && oldVal >= 480) { sideBarHidden.value = true }

        // if(newVal < 480)
        //     sideBarHidden.value = true

        // if(newVal > 480)
        //     sideBarHidden.value = false   
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

    const accountsStore                 = useAccountsStore()
    const       
    {       
        accountsList:    itemsList,        
        accountsPager:   listPager,       
        detailAccountId: activeDetailId       
    }                                   = storeToRefs(accountsStore)
    const { getPagedAccounts }          = accountsStore

    const listPageSizeDefault           = useLocalStorage(pageSizeDefaultName, 15)
    listPager.value.PageSize            = listPageSizeDefault

    const searchFilterDefault           = persistSearch.value ? useLocalStorage(searchFilterDefaultName, '') : ''
    listPager.value.Search              = new SearchForAccount(searchFilterDefault)  

    // Methods / Computeds ===========================================================================

    const activeListItemId      = computed(() => activeItem.value ? activeItem.value[detailKeyName] : 0) 

    const resetFilter           = ()        => listPager.value.Search.Filter = ''
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
        // console.log('refreshList: ' + forceRefresh)

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
            let newPager                = new Pager()
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
        else if (e.code === 'Home')       { listPager.value.goToFirstPage();    e.preventDefault();}
        else if (e.code === 'End')        { listPager.value.goToLastPage();     e.preventDefault();}
        else if (e.code === 'PageDown')   { listPager.value.goToPreviousPage(); e.preventDefault();}
        else if (e.code === 'PageUp')     { listPager.value.goToNextPage();     e.preventDefault();} 

        // 'Ctrl+S' to Save is in AccountsDetail control
    }

	KeyboardListeners(keys);

    // Lifecycle & Watches  ==========================================================================

    onMounted(() =>    
    {        
        refreshList(1, true)
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
    <div class="" id="accountsList">

        <ListPagerPrevNext :pager="listPager"></ListPagerPrevNext>

        <!-- grey: bg-[#929292] filterInput: shadow-[-2px_2px_2px_2px_rgba(0,0,0,0.1)] ended up no.-->

        <div class="px-5 flex flex-wrap justify-between items-center border-t border-r border-slate-300
            bg-gradient-side shadow-[0_10px_30px_-5px_rgb(0,0,0,0.4)] xxs:shadow-none">
            
            <div class="flex gap-x-1 pt-5 pb-3 w-full">
                <div class="h-10 w-full relative">
                    <input class="rounded-full w-full h-full pl-5 pr-5 sm:pr-9 select-all border-color-dark-gray"
                        id="filterInput" type="text" v-model="listPager.Search.Filter" placeholder="Search" spellcheck="false"
                        title="Search the list for Account Names that start with this text. Add multiple conditions 
                                separated by a comma. Click on + for more options." />
                
                    <div class="top-0 right-0 flex justify-end items-center gap-1 absolute h-full w-auto">
                        <div class="p-1 w-auto flex-center" @click="resetFilter">
                            <IconSymbol v-if="listPager.Search.Filter.length > 0" 
                                 class="xs:hidden sm:block text-color-dark-gray hover:text-color-mid-gray" width="22px" icon="heroicons:x-mark" />
                        </div>
                        <span class="p-1 mr-1.5 bg-color-mid-gray hover:bg-color-light-gray
                            flex-center rounded-full group" @click.prevent="showAdvSearch=true">
                            <IconSymbol class="text-black group-hover:text-color-mid-gray"
                                title="Advanced Search"  width="22px" icon="heroicons:plus-20-solid" />
                        </span>
                    </div>
                </div>
            </div>
            <div v-if="listPager.Search.StateProvinceFilter.length > 0" class="">
                Filters: {{ listPager.Search.StateProvinceFilter }}
            </div>
            <div class="w-full flex justify-between items-center select-none my-3">
                <ListPager class="mr-2" id='listPager' v-bind:pager="listPager"></ListPager>
                <span class="text-sm xs:hidden md:inline whitespace-nowrap">Total: {{listPager.TotalCount || 0 }}</span>
            </div>
        </div>

        <table class="w-full bg-gray-100 select-none shadow-[0_10px_30px_-5px_rgb(0,0,0,0.4)] 
            xs:shadow-none" id="accounts-list-table">
            <thead class="text-left bg-gradient-table-head border-t border-gray-300 ">
                <th class="w-6 sm:w-8 py-5 bg-[#ddd]"></th>
                <th class="hidden md:table-cell pr-4 select-none bg-[#ddd]">Id</th>
                <th class="pr-4 min-w-[100px]">Account</th>
            </thead>
            <tbody v-if="listHasRecords()" >
                <tr v-for="(a, index) in itemsList" class="border-y bg-gradient-side2 border-gray-300"
                    :class="{ 'active-row' : isActiveItem(a.AccountId) }"
                    @click="refreshItem(index)" :key="a.AccountId">
                    <td class="w-6 p-0 sm:w-8 select-none bg-white">
                        <div v-if="isActiveItem(a.AccountId)" class="active-arrow" >&nbsp;</div>
                        <!-- or active-arrow -->
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