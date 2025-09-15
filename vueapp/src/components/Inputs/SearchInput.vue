<script setup>


    const props = defineProps (
    {
        showAdvSearchButton: { type: Boolean, default: true },
        inputTitle:  { type: String, default: 
            "Search the list for values that start with this text. " +
            "Add multiple conditions separated by a comma. Click on + for more options." }
    })

    const modelValue    = defineModel(
    {   set(value)
        { 
            console.log('setting SearchInput modelValue: ' + value)
            return value
        }
    }
    ) 
    const showAdvSearch = defineModel('showAdvSearch')
    const filterInput   = ref(null)

    // -------------------------------------------------------------------

    const resetFilter   = () => modelValue.value.Search.Filter = ''
    const focusInput    = () => filterInput.value?.focus()

    defineExpose({ focusInput }) // exposes to Parent

</script>


<template>
    <div class="h-8 w-full relative">
        <input class="text-sm rounded-full w-full h-full pl-5 pr-5 sm:pr-9 select-all border-color-dark-gray"
            id="filterInput" type="text" v-model="modelValue" placeholder="Search" spellcheck="false"
            ref="filterInput" :title="props.inputTitle" />
        
        <div class="top-0 right-0 flex justify-end items-center gap-0 absolute h-full w-auto">
            <div class="p-1 w-auto flex-center" @click="resetFilter">
                <IconSymbol v-if="modelValue.length > 0" 
                    class="xs:hidden sm:block text-color-dark-gray hover:text-color-mid-gray" width="22px" icon="heroicons:x-mark" />
            </div>
            <span v-if="showAdvSearchButton"
                class="mr-1.5 bg-color-mid-gray hover:bg-color-light-gray
                flex-center rounded-full group" @click.prevent="showAdvSearch=true">
                <IconSymbol class="text-black group-hover:text-color-mid-gray"
                    title="Advanced Search" width="22px" icon="heroicons:plus-20-solid" />
            </span>
        </div>
    </div>
</template>

<!-- Usage (with custom inputTitle):

    <SearchInput v-model="listPager.Search.Filter" v-model:showAdvSearch="showAdvSearch" 
        inputTitle="Search Account list for values that start with this text."></SearchInput>

    <SearchInput v-model="listPager.Search.Filter" v-model:showAdvSearch="showAdvSearch" 
        :showAdvSearchButton="false" />   
-->

