<script setup>

	const authStore			    = useAuthStore()
	const { tokenExpiration }   = storeToRefs(authStore)

</script>

<template>
		
	<LayoutMain>

		<SubNavBar class="relative overflow-hidden">
		
			<div class="pl-5 flex items-center">
				<!-- <RotateButton v-model="sideBarHidden" class="" title="toggle search"  />  -->
				<span class="font-bold">Token Exp: </span>
				<span class="ml-3">{{ dateTimeFormat(tokenExpiration, 'h:mm:ssa') }}</span>
			</div>

			<div class="sm:pr-5"></div>
			
		</SubNavBar>

		<HomeView />

	</LayoutMain>
		
</template>
