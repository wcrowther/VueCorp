
<script setup>

	const authStore				= useAuthStore()
	const { login, signup }		= authStore
	const loginUser   			= () => login(userData.value)
	const signupUser   			= () => signup(userData.value)
	const showSignup			= ref(false)
	const userData 				= ref(new User())
	const rules 				= computed(() => showSignup.value ? authSignupValidator : authRequestValidator )
	const v$ 					= useVuelidate(rules, userData.value)
	const validateAndLogin		= async () =>
	{
		let isValidAuth = await v$.value.$validate()

		if(isValidAuth)	
			loginUser()
		else
			console.log(`IsValidAuth: ${isValidAuth}`) // OR USE MESSANGER HERE
	}

</script>

<template>

	<LayoutLogin>

		<div id="mainContent" class="p-10 pb-12 relative h-full bg-color-lighter-gray"> 

			<template v-if="showSignup">
				<TextInput 		labelName="First Name" 	v-model="userData.FirstName" :v$ />
				<TextInput 		labelName="Last Name"  	v-model="userData.LastName"  :v$ />
				<TextInput 		labelName="User Email" 	v-model="userData.UserEmail" :v$ />
				<TextInput 		labelName="UserName" 	v-model="userData.UserName"  :v$ />
				<PasswordInput  labelName="Password" 	v-model="userData.Password"  :v$ />
				<div class="select-none pt-5 flex justify-end gap-3 mb-5">
					<button class="btn-primary" @click="signupUser">New User Sign Up</button>
					<button class="btn-delete" @click="showSignup=false">Cancel</button>
				</div>	
			</template>
			<template v-else>
				<TextInput 		labelName="UserName" 	v-model="userData.UserName" :v$ />
				<PasswordInput 	labelName="Password" 	v-model="userData.Password" :v$ />
				<div class="select-none pt-5 flex justify-between gap-3 mb-20">
					<span class="btn-secondary" @click="showSignup=true">New User Signup</span>
					<button class="btn-primary" @click.prevent="validateAndLogin">Login</button>
				</div>	
			</template>

		</div>

	</LayoutLogin>	

</template>

<style lang="postcss" scoped></style>



