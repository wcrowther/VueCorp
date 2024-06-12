<script setup>

    import ReverseCorner from '@/components/ReverseCorner.vue'

    const props = defineProps(
	{
		navText: { type: String, required: true }
	});

</script>

<template>

<router-link class="nav-tab" active-class="active-tab">

	<span class="">{{props.navText}}</span>
	<ReverseCorner :pixelSize="7" class="hidden bottom-0 left-[-7px]" />
    <ReverseCorner :pixelSize="7" class="hidden bottom-0 right-[-7px] rotate-90" />	

</router-link>

</template>

<style lang="postcss" scoped>

	.nav-tab {
		@apply text-[#121639] font-semibold font-sans text-base/10 rounded-t-md list-none h-9 px-4
		flex relative bg-color-light-blue hover:bg-transparent hover:text-white opacity-80
	}    
	.active-tab {
		@apply text-orange hover:text-black bg-gradient-tab-active opacity-100
	}
	.active-tab .corner {
		@apply block
	}
	
</style>
