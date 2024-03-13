<script setup>

    import ReverseCorner from '@/components/ReverseCorner.vue'

    const props = defineProps(
	{
		navText:        { type: String, required: true },
		// navTo:          { type: String, default: 'Confirm' }
		// activeClass:    { type: String, default: 'active-tab' } 
        // active-class="active-tab" to="/"
	});

	// CURRENTLY REVERSE CORNERS ARE NOT WORKING

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
		@apply text-[#121639] font-semibold font-sans text-base/9 rounded-t-md list-none h-8 px-3
		flex relative bg-color-light-blue hover:bg-transparent hover:text-white opacity-80
	}    
	.active-tab {
		@apply text-orange hover:text-black bg-gradient-tab-active opacity-100
	}
	.active-tab .corner {
		@apply block
	}
	
</style>
