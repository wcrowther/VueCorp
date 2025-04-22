<script setup>

    const listPager     = defineModel('listPager')
    const show          = defineModel('show')

    const emits         = defineEmits(["getListData"])
    const getListData   = () => emits('getListData')

</script> 

<template>   

	<ModalControl :show="show" title="Advanced Search" id="AccountAdvSearch"
        height="400px" width="500px" @closeModal="show=false">

        <div class="p-5 pb-0">
            <SelectInput labelName="PageSize" v-model="listPager.PageSize" 
                :optionsList="pagerPageSize" :showDefault="false"  
                title="Change how many records in each page of data." />
        </div>

        <template #footer>
            <button class="btn-primary"  @click="getListData">Refresh</button>
            <button class="btn-delete"   @click="show=false">Close</button>
        </template>

	</ModalControl>

</template>


<!-- 
Usage:
        <UserAdvSearch v-model:show="showAdvSearch" v-model:listPager="listPager" 
            @getListData="getListData"></UserAdvSearch>
-->
