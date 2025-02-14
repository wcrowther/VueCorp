<script setup>

    const props = defineProps(
	{
		navText: { type: String }
	});

</script>

<template>

<router-link class="nav-tab" active-class="active-tab">

	<slot>	
		<span class="">{{props.navText}}</span>
	</slot>
	<ReverseCorner :pixelSize="7" class="hidden bottom-0 left-[-7px]" />
    <ReverseCorner :pixelSize="7" class="hidden bottom-0 right-[-7px] rotate-90" />	

</router-link>

</template>

<style lang="postcss" scoped>

	.nav-tab {
		@apply text-[#bddaef] font-semibold tracking-wide font-sans rounded-full list-none px-4 h-[28px] text-sm
		flex items-center relative bg-[#445292] mb-[8px] hover:bg-transparent hover:text-white opacity-80
	}    
	.active-tab {
		@apply text-orange hover:text-black bg-gradient-tab-active rounded-t-md opacity-100 m-0 h-9 rounded-b-none
	}
	.active-tab .corner {
		@apply block
	}
	
</style>
