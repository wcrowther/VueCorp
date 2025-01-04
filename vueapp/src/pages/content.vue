<!-- eslint-disable vue/multi-word-component-names -->

<script setup>

	import { definePage } from 'vue-router/auto'
	definePage({ redirect: '/Content/Main' })
	
</script>

<template>
	<LayoutMain>
		
		<SubNavBar class=""></SubNavBar>
		
		<router-view />

	</LayoutMain>
</template>
	