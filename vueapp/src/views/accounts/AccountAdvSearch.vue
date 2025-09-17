<script setup>

    const listPager     = defineModel('listPager', { type: PagerModel, required: true })
    const showModal     = defineModel('showModal', { type: Boolean, required: true })

    const emits         = defineEmits(['getListData'])
    
    const resetAdvSearch = () => 
    {
        console.log('resetAdvSearch')

        listPager.value.Search.FilterType           = 'startswith'
        listPager.value.PageSize                    = 15
        listPager.value.Search.StateProvinceFilter  = ''
        listPager.value.Search.PostalCodeFilter     = ''

        emits('getListData')
    }

	// Keyboard Listeners  ================================================

	DisableLayoutEscapeKey()

	const keys = function (e)   
    {
		if (e.code === 'Escape'){ showModal.value=false; e.preventDefault(); } 
    }

	KeyboardListeners(keys)

</script> 

<template>   

	<ModalControl id="AccountAdvSearch" :showModal="showModal" 
        title="Advanced Search" height="500px" width="500px" 
        @closeModal="showModal=false" >

        <div class="p-5 pb-0">
        
            <SelectInput labelName="Search Type" v-model="listPager.Search.FilterType" 
                :optionsList="filterTypes" :showDefault="false"  
                title="Filter AccountName by 'Starts With', 'Contains' or 'Ends With'." />

            <SelectInput labelName="Page Size" v-model="listPager.PageSize" 
                :optionsList="pagerPageSize" :showDefault="false"  
                title="Change how many records in each page of data." />

            <SelectInput labelName="State / Province Filter" v-model="listPager.Search.StateProvinceFilter" 
                :optionsList="usStatesList" defaultText="--- None ---" :disableDefault="false" 
                title="Filter to a State or Province." />

            <TextInput labelName="Postal Code Filter" placeholder="30000" 
                v-model="listPager.Search.PostalCodeFilter" 
                title="Filter to a Postal (or Zip) Code" />
        </div>

        <template #footer>
            <button class="btn-primary"  @click="resetAdvSearch">Reset</button>
            <button class="btn-delete"   @click="showModal=false">Close</button>
        </template>

	</ModalControl>

</template>


<!-- Usage:

    <AccountAdvSearch v-model:show="showAdvSearch" v-model:listPager="listPager" 
        @getListData="getListData">
    </AccountAdvSearch>
-->
