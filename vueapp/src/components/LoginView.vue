<script setup>

	const authStore			= useAuthStore()
	const { login }			= authStore

	const authModel			= new AuthRequest()
	const authRequest 		= ref(authModel)
	const v$ 				= useVuelidate(authRequestValidator, authRequest.value)

	const loginUser   		= () => login(authRequest.value)
	const validateAndLogin	= async () =>
	{
		let isValidAuth = await v$.value.$validate()

		if(isValidAuth)	
			loginUser()
		else
			console.log(`IsValidAuth: ${isValidAuth}`) // OR USE MESSENGER HERE
	}

</script>

<template>

	<TextInput 		labelName="UserName" 	v-model="authRequest.UserName" :v$ />
	<PasswordInput 	labelName="Password" 	v-model="authRequest.Password" :v$ />

	<div class="select-none pt-5 flex justify-between gap-3 mb-20">
		<slot></slot>
		<button class="btn-primary" @click.prevent="validateAndLogin">Login</button>
	</div>	

</template>


