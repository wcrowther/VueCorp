<script setup>

    const messageStore      = useMessageStore()
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
			return loginUser()

		messageStore.showInfo('Please enter a valid UserName and Password');
		console.log(v$.value.$errors.map(e => `${e.$property} : ${e.$message}`).join('\n'))

		// Alternate version:
		// v$.value.$errors.forEach(error => {
		// 	console.log(`${error.$property} : ${error.$message}`) 
		// });
	}

</script>

<template>

	<form id="LoginView">
		<TextInput 		labelName="UserName" autocomplete="username" v-model="authRequest.UserName" :v$ />
		<PasswordInput 	labelName="Password" autocomplete="password" v-model="authRequest.Password" :v$ />

		<div class="select-none pt-5 flex justify-between gap-3 mb-20">
			<slot></slot>
			<button class="btn-primary" @click.prevent="validateAndLogin">Login</button>
		</div>	
	</form>

</template>


