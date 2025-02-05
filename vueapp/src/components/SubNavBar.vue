<script setup>

    const appStore      = useAppStore()
    const { infoLevel } = storeToRefs(appStore)

</script>

<template>
    <div class="relative h-14 pl-5 pr-10 flex justify-end items-center bg-white select-none">
        
        <div class="mr-auto">
            <slot name="leftalign"></slot>
        </div>
        <slot></slot>
        <InfoButton v-model="infoLevel"></InfoButton>
    </div>
</template>

