<script setup>

	RedirectToPage('/accounts','/accounts/main')

    const appStore              = useAppStore()
    const { sideBarHidden }     = storeToRefs(appStore)

</script>

<template>
	<LayoutMain>
		
		<SubNavBar> 

			<template #leftalign>
				<RotateButton v-model="sideBarHidden" class="" title="toggle search"  /> 
			</template>

			<div class="pr-5">
				<router-link to="/accounts/main"  linkName="AccountsMain"
					class="px-1 py-2 font-bold hover:opacity-50" active-class="subnav-active">
					Main
				</router-link>

				<span class="px-1 text-gray-300">|</span>

				<router-link to="/accounts/messages" linkName="AccountsMessages" 
					class="px-1 py-2 font-bold hover:opacity-50" active-class="subnav-active">
					Messages
				</router-link>

				<span class="px-1 text-gray-300">|</span>

				<router-link to="/accounts/wizard" linkName="AccountsWizard" 
					class="px-1 py-2 font-bold hover:opacity-50" active-class="subnav-active">
					Wizard
				</router-link>
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
	