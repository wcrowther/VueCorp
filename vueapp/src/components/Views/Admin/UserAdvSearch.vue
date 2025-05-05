<script setup>

    const listPager     = defineModel('listPager')
    const showModal     = defineModel('showModal')

    const emits         = defineEmits(["getListData"])
    const getListData   = () => emits('getListData')

</script> 

<template>   

	<ModalControl :showModal="showModal" title="Advanced Search" id="UserAdvSearch"
        height="400px" width="500px" @closeModal="showModal=false">

        <div class="p-5 pb-0">
            <SelectInput labelName="PageSize" v-model="listPager.PageSize" 
                :optionsList="pagerPageSize" :showDefault="false"  
                title="Change how many records in each page of data." />
        </div>

        <template #footer>
            <button class="btn-primary"  @click="getListData">Refresh</button>
            <button class="btn-delete"   @click="showModal=false">Close</button>
        </template>

	</ModalControl>

</template>


<!-- 
Usage:
    <UserAdvSearch v-model:show="showAdvSearch" v-model:listPager="listPager" 
        @getListData="getListData"></UserAdvSearch>
-->
