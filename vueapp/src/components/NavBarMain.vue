
<script setup>

	const authStore     	= useAuthStore()
	const appStore     		= useAppStore()

	const { authUser  } 	= storeToRefs(authStore)
	const { altColors }		= storeToRefs(appStore)

</script>

<template>

    <NavBar id="nav-bar" :class="[altColors ? 'navbar-gradient-alt' : 'navbar-gradient']">

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
	
<style lang="postcss" scoped>

	.navbar-gradient { @apply bg-[linear-gradient(90deg,#7ab7d8_2%,#1c2157_50%)] md:ml-3 } 
	.navbar-gradient-alt { @apply bg-[linear-gradient(90deg,#f9f9f9_0%,#c2c2c2_100%)] md:ml-3 } 

</style>