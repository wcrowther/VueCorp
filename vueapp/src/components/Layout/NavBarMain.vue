
<script setup>

	const authStore     	= useAuthStore()
	const { authUser  } 	= storeToRefs(authStore)

	const adminRoles 		= ['Admin', 'SuperAdmin']

</script>

<template>

    <NavBar id="nav-bar" class="bg-gradient-navbar md:ml-3">

		<NavTab to="/" class="group">
			<IconSymbol width="18px" class="text-[#bddaef] block xs:hidden
				group-hover:text-navy group-hover:opacity-100" icon="heroicons-solid:home" />
			<span class="hidden xs:block">Home</span>
		</NavTab>

		<!-- <NavTab navText="Content" to="/content" /> -- Hide until Content is complete -->

		<NavTab navText="Accounts" 	to="/accounts" />

		<NavTab navText="Admin" 	to="/admin"  v-if="adminRoles.includes(authUser.Role)" />

	</NavBar>

</template>

