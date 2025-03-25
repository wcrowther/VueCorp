<script setup>
	const appStore                      = useAppStore()
	const { infoLevel }                 = storeToRefs(appStore)
</script>

<template>
    <div v-if="infoLevel > 1" 
        class="text-sm mb-3">
        <slot></slot>
    </div>
</template>

