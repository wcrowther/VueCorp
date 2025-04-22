<script setup>
	const appStore       = useAppStore()
	const { infoLevel }  = storeToRefs(appStore)
</script>

<template>
    <div v-if="infoLevel > 2" 
        class="mb-3 text-sm border border-[#f97316] bg-white rounded-xl px-5 py-6 w-full">

        <span class="float-right relative -top-5 -right-4 badge-button text-white bg-orange" 
            @click="infoLevel=2"  @click.right.prevent="infoLevel=1">
            Help
        </span> 

        <slot></slot>
    </div>
</template>

<!-- 
USE:  Wrap around content that you only want to appear when infoLevel is Help (3)
      determined by the InfoLevel control.

EXAMPLES: 

    <HelpBox>
        Voluptates accusamus repudiandae quam officiis temporibus dicta ipsa iure? 
    </HelpBox>
-->

