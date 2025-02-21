
<script setup>

	const authStore     		= useAuthStore()
	const { authUser  } 		= storeToRefs(authStore)

</script>

<template>

    <NavBar id="nav-bar" class="navbar-gradient">

		<NavTab to="/" class="group">
			<IconSymbol width="18px" class="text-[#bddaef] block xs:hidden
				group-hover:text-white group-hover:opacity-100" icon="heroicons-solid:home" />
			<span class="hidden xs:block">Home</span>
		</NavTab>

		<!-- <NavTab navText="Content" to="/content" /> -- Hide until Content is complete -->

		<NavTab navText="Accounts" 	to="/accounts" />

		<NavTab navText="Admin" 	to="/admin"  v-if="authUser.Role == 'Admin'" />

	</NavBar>

</template>