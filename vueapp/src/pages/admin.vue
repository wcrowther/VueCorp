<script setup>

	const router = useRouter();
	router.replace('/admin/users'); // Redirects to target route
	
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
			
				<router-link to="/Admin/Users" class="px-1 py-2 font-bold hover:opacity-50" 
					active-class="text-orange" linkName="AdminUsers">Users</router-link>

				<span class="px-1 text-gray-300">|</span>

				<router-link to="/Admin/Notes" class="px-1 py-2 font-bold hover:opacity-50" 
					active-class="text-orange" linkName="AdminNotes">Notes</router-link>

				<span class="px-1 text-gray-300">|</span>

				<router-link to="/Admin/Site" class="px-1 py-2 font-bold hover:opacity-50" 
					active-class="text-orange" linkName="AdminSite">Site</router-link>
			</div>  

		</SubNavBar>
		
		<router-view />

	</LayoutMain>
</template>
	