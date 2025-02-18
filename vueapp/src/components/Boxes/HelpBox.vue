<script setup>
	const appStore       = useAppStore()
	const { infoLevel }  = storeToRefs(appStore)
</script>

<template>
    <div v-if="infoLevel > 2" 
        class="text-sm border border-[#f97316] bg-white rounded-xl p-5 pb-6 w-full">
        <span class="float-right relative -top-2 -right-2 
            badge-button text-white bg-orange" 
            @click="infoLevel=2" 
            @click.right.prevent="infoLevel=1" >
            Help
        </span> 
        <slot></slot>
    </div>
</template>

