<script setup>

const listPager = defineModel('listPager')
const show      = defineModel('show')

</script> 

<template>   

	<ModalControl :show="show" title="Advanced Search" 
        height="400px" width="500px" @closeModal="show=false">

        <div class="">
            <SelectInput labelName="PageSize" v-model="listPager.PageSize" 
                :optionsList="pagerPageSize" :showDefault="false"  />
            <SelectInput labelName="State / Province" v-model="listPager.Search.StateProvinceFilter" 
                :optionsList="usStatesList" defaultText="-----" :defaultDisabled="false" />
            <TextInput labelName="Postal Code" placeholder="-----" v-model="listPager.Search.PostalCodeFilter"  />
        </div>

        <template #footer>
            <button class="custom-button"  @click="show=false">Close</button>
        </template>

	</ModalControl>

</template>


<!-- 
Usage:
    <AccountAdvSearch v-model:show="showAdvSearch" v-model:listPager="listPager" />
-->