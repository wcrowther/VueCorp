
<script setup>

	const authStore					= useAuthStore()
	const { login, signup }			= authStore
	const loginUser   				= () => login(userData)
	const signupUser   				= () => signup(userData)
	const showSignup				= ref(false)

	// const { authUser }			= storeToRefs(authStore)

	const userData = reactive(
	{
		FirstName: 	'Will',
		LastName: 	'Test',
		UserName: 	'wcrowther22',
		Password: 	'Test123!',
		UserEmail:	'testuser3333@test.com'
	})

	const rules 			= computed(() =>showSignup ? authSignupValidator : authRequestValidator )
	const v$ 				= useVuelidate(rules, userData)
	const validateAndSave 	= async () =>
    {
        let isValidAuth = await v$.value.$validate()
		if(isValidAuth)	
			loginUser()
    }

</script>

<template>

	<LayoutLogin>

		<BrandBar class="main-width">
			<BrandLogo></BrandLogo>
		</BrandBar>  

		<div id="mainContent" class="p-10 pb-12 main-width relative h-full bg-color-lighter-gray"> 

            <div v-if="showSignup" class="">
				<TextInput labelName="First Name" v-model="userData.FirstName" :v$ />
				<TextInput labelName="Last Name"  v-model="userData.LastName"  :v$ />
				<TextInput labelName="User Email" v-model="userData.UserEmail" :v$ />
			</div>

            <TextInput     labelName="UserName" v-model="userData.UserName" :v$ />
			<PasswordInput labelName="Password" v-model="userData.Password" :v$ />

			<div v-if="!showSignup" class="select-none pt-5 flex justify-between gap-3 mb-20">
				<span class="link-underline" @click="showSignup=true">New User Signup</span>
				<button class="custom-button" @click.prevent="validateAndSave">Login</button>
			</div>	
			<div v-else class="select-none pt-5 flex justify-end gap-3 mb-5">
				<button class="custom-button" @click="signupUser">New User Sign Up</button>
				<button class="default-button" @click="showSignup=false">Cancel</button>
			</div>			
		</div>

	</LayoutLogin>	

</template>

<style lang="postcss" scoped></style>



