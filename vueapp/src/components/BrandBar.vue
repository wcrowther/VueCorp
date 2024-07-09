<script setup>
    const appStore     		= useAppStore()
    const { altColors } 	= storeToRefs(appStore)
</script>

<template>
    <div class="select-none h-20 flex justify-between items-center px-4 pr-5" id="BrandBar"
        :class="[altColors ? 'bg-gradient-brand-alt' : 'bg-gradient-brand']" >
        <!-- <img src="/space-stars.png" class="h-[200px] w-[500px] z-10" />  -->
        <slot></slot>
    </div>
</template>

