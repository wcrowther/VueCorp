<!-- 
TODO: 
1) add other filters
    a) Search Type
    b) PaageSize
    c) Postal Code
    
2) clicking text launches AdvSearch
-->

<script setup>

    const props = defineProps(
    {
        listPager: { type: PagerModel, required: true },
    })

</script> 

<template>   

    <div v-if="props.listPager.Search.StateProvinceFilter?.length > 0" 
        class="text-sm mt-2 italic">
        Filters: {{ usStatesList[props.listPager.Search.StateProvinceFilter] }}
    </div>

</template>


<!-- Usage: AccountFilters usage to come -->
