<script setup>
    const appStore     		= useAppStore()
    const { altColors } 	= storeToRefs(appStore)
</script>

<template>
    <div class="select-none h-20 flex justify-between has-[>:only-child]:justify-end items-center px-4 pr-5" id="BrandBar"
        :class="[altColors ? 'bg-gradient-brand-alt' : 'bg-gradient-brand']" >
        <slot></slot>
    </div>
</template>

