<script setup>

	import { definePage } from 'vue-router/auto'
	definePage({ redirect: '/Accounts/Main' })

    const appStore              = useAppStore()
    const { sideBarHidden }     = storeToRefs(appStore)

</script>

<template>
	<LayoutMain>
		
		<SubNavBar class="relative overflow-hidden">  
		
			<div class="flex items-center">
				<RotateButton v-model="sideBarHidden" class="" title="toggle search"  /> 
				<!-- 
				<div @click="sideBarHidden=!sideBarHidden" 
					class="pl-3 hover:opacity-50 cursor-pointer">
					{{ sideBarHidden?'Show':'Hide' }} Search
				</div>
				-->
			</div>

			<div class="pr-5">
				<router-link to="/Accounts/Main" class="px-1 py-2 font-bold hover:opacity-50" 
					active-class="subnav-active" linkName="AccountsMain">Main</router-link>

				<span class="px-1 text-gray-300">|</span>

				<router-link to="/Accounts/Edit" class="px-1 py-2 font-bold hover:opacity-50" 
					active-class="subnav-active" linkName="AccountsEdit">Edit</router-link>

				<!-- 
				<router-link to="/Accounts/View" class="px-1 py-2 font-bold hover:opacity-50" 
					active-class="subnav-active" linkName="AccountsView">View</router-link>
				<span class="px-1 text-gray-300">|</span> 
				-->
			</div>

		</SubNavBar>
		
		<router-view /> 
	
	</LayoutMain>
</template>

<style lang="postcss" scoped>
    .subnav-active {
        @apply text-orange hover:opacity-50
    }

</style> 
	