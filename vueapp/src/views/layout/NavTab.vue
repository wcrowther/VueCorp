<script setup>

    const props = defineProps({ navText: { type: String } });
	
</script>

<template>

	<router-link class="nav-tab font-semibold tracking-wide font-sans rounded-full 
		list-none px-4 pt-px h-[28px] text-sm flex items-center relative mb-[6px]" 
		active-class="active-tab">

		<slot>
			<span>{{props.navText}}</span>
		</slot>

		<ReverseCorner :pixelSize="7" class="hidden bottom-0 left-[-7px]" />
		<ReverseCorner :pixelSize="7" class="hidden bottom-0 right-[-7px] rotate-90" />	

	</router-link>

</template>

<style> /* See @layer utilities in tailwindcss.config.js */</style>