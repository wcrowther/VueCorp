<script setup>

    import { Icon } from '@iconify/vue'

    /*  
    ============================================================================================
    Wrapper for Iconify 'Icon' component
    ============================================================================================
    https://icones.js.org/ - list of icons
    https://icones.js.org/collection/heroicons
    https://iconify.design/docs/icon-components/vue/

    Examples:

    <IconSymbol class="text-color-red" icon=heroicons:chevron-right-solid" />
    <IconSymbol width="28px" class="text-warm" @click="deleteProp" icon="heroicons:x-circle-20-solid" />
    <IconSymbol width="32px" class="text-color-dark-gray" icon="heroicons:bars-4" />
    <IconSymbol width="28px" class="text-color-dark-gray" icon="heroicons:cog-8-tooth-solid" />
    
    <IconSymbol width="18px" class="mt-[10px] mr-1 text-color-dark-gray
					group-hover:text-white group-hover:opacity-100" icon="heroicons-solid:home" />

    <IconSymbol :inline="false" :vertical-flip="true" class="border border-red"
        color="red"  width="96px" icon="mdi:arrow-down-box" />

    <IconSymbol class="transition-transform duration-500" :class="{'rotate-[-450deg]': isTop}"
        :color="isTop ? 'green': 'red'" @click="isTop=!isTop" width="96px" icon="mdi:arrow-down-thick"  />
    ============================================================================================
    */

	const props = defineProps(
	{
		inline: { type: Boolean, default: true }
	});


</script>

<template>
    <Icon :inline="props.inline" :class="{'inline': props.inline}" />
</template>

