<script setup>

	// import { storeToRefs } 		from 'pinia'
	// import { useAccountsStore } from '@/stores/accounts'
	// import { useAppStore } 		from '@/stores/app'
	// import { usePagedList } 	from '@/composables/usePagedList'

	// Stores
	const accountsStore = useAccountsStore()
	const appStore      = useAppStore()

	// Store refs
	const { getPagedAccounts } = accountsStore

	const { accountsList: itemsList,
			accountsPager: listPager,
			detailAccountId: activeDetailId } = storeToRefs(accountsStore)
	const { persistSearch }                   = storeToRefs(appStore)

    const showAdvSearch = ref(false)

	// Use the generic paged pList composable
	const pList = usePagedList(
	{
		showAdvSearch,
        getPagedItems: getPagedAccounts,
		itemsList,
		listPager,
		activeDetailId,
		persistSearch,
		detailKeyName: 'AccountId',
		pageSizeDefaultName: 'accountsPageSizeDefault',
		searchFilterDefaultName: 'accountsSearchFilterDefault',
		createSearchModel: () => new SearchForAccount(''),   // 👈 specific Search
	})

    // Keyboard handler =======================================================

    const searchInput = useTemplateRef('searchInput')

    const keys = function (e) 
	{
        if      (e.code === 'ArrowUp')   { listPager.value.goToPrevious();      e.preventDefault() }
        else if (e.code === 'ArrowDown') { listPager.value.goToNext();          e.preventDefault() }
        else if (e.code === 'PageDown')  { listPager.value.goToPreviousPage();  e.preventDefault() }
        else if (e.code === 'PageUp')    { listPager.value.goToNextPage();      e.preventDefault() }
        else if (e.code === 'Home')      { searchInput.value.focusInput();      e.preventDefault() }
    }

    KeyboardListeners(keys);


</script>

<template>
    <div id="accountsList">

        <div class="px-5 pb-3 flex flex-wrap justify-between items-center border-t border-r border-slate-300
            bg-gradient-side shadow-[0_10px_30px_-5px_rgb(0,0,0,0.4)] xxs:shadow-none">

            <div class="flex gap-x-1 pt-5 w-full">
                <SearchInput
                    ref="searchInput" 
                    v-model="pList.listPager.value.Search.Filter" 
                    v-model:showAdvSearch="showAdvSearch" />
            </div>

            <div v-if="pList.listPager && pList.listPager.Search && 
					pList.listPager.Search.StateProvinceFilter?.length > 0" 
                class="ml-5 text-sm mt-2 italic">
                Filters: {{ pList.listPager.Search.StateProvinceFilter }}
            </div>

            <div class="w-full flex justify-between items-center select-none my-3">
                <ListPager 
					class="mr-2" id='listPager' v-bind:pager="pList.listPager.value" />
                <span class="text-sm xs:hidden md:inline whitespace-nowrap">
                    Total: {{ pList.listPager.TotalCount || 0 }}
                </span>
            </div>

            <InfoBox class="mb-3">
                Enter search text for the start of an Account Name or Id. 
            </InfoBox>

            <HelpBox class="mb-3" :compact="true">
                You can add multiple conditions separated by a comma.
                Click on the + sign for the Advanced Search with additional options.
            </HelpBox>
            
            <MobilePagerPrevNext :pager="pList.listPager" />

        </div>

        <table class="w-full bg-gray-100 select-none xs:shadow-none
            shadow-[0_10px_30px_-5px_rgb(0,0,0,0.4)]" id="accounts-list-table">

            <thead class="text-left bg-gradient-table-head border-t border-gray-300 ">
                <tr>
                    <th class="w-6 sm:w-8 py-5 bg-[#ddd]"></th>
                    <th class="hidden md:table-cell pr-4 select-none bg-[#ddd]">Id</th>
                    <th class="pr-4 min-w-[100px]">Account</th>
                </tr>
            </thead>

            <tbody v-if="pList && pList.listHasRecords()">
                <tr v-for="(a, index) in itemsList" 
                    class="border-y bg-gradient-side2 border-gray-300"
                    :class="{ 'active-row' : pList.isActiveItem(a.AccountId) }"
                    @click="pList.refreshItem(index)" :key="a.AccountId">

                    <td class="w-6 p-0 sm:w-8 select-none bg-white">
                        <div v-if="pList.isActiveItem(a.AccountId)" class="active-arrow">&nbsp;</div>
                    </td>

                    <td class="hidden md:table-cell pr-4 py-1 text-sm">
                        {{ a.AccountId }}
                    </td>

                    <td class="pr-4 py-1 h-8 max-w-[200px] break-words text-sm"
                        :title="'Account Id: ' + a.AccountId">
                        {{ a.AccountName }}
                    </td>
                </tr>
            </tbody>

            <tbody v-else class="h-20 text-center font-bold">
                <tr>
                    <td colspan="3" class="px-4 py-1">No Accounts found</td>
                </tr>
            </tbody>

            <tfoot>
                <tr>
                    <td colspan="3" class="h-8 bg-[#e9e9e9]">&nbsp;</td>        
                </tr>
            </tfoot>
        </table>

		<AccountAdvSearch 
            v-model:showModal="showAdvSearch" 
            v-model:listPager="pList.listPager" 
            @getListData="pList.getListData" /> 
    </div>

</template>

<style lang="postcss" scoped>
	.active-row   { @apply bg-gradient-white }
	.active-arrow { @apply w-0 h-0 border-x-[8px] border-y-[6px] border-transparent border-l-[#91a5bd] relative left-3 }
	.reset-x      { @apply text-black hover:text-color-mid-gray }
</style>
