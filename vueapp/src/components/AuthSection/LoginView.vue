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
		<div class="select-none pt-5 flex justify-between gap-3 mb-10">
			<slot></slot>
			<button class="btn-primary" @click.prevent="validateAndLogin">Login</button>
		</div>
	</form>
	<div class="mb-10 flex flex-wrap">
		<div class="w-full mb-5">New users click
			<span class="italic font-bold">New User Signup</span> above or use the login below. User 
			data will be persisted but will be wiped on an intermittent basis. Note that this password
			is not secure and can easily be discovered.</div>
		<div class="w-1/2"><b>UserName:</b> testuser</div>
		<div class="w-1/2 text-end"><b>Password:</b> Test123!</div>
	</div>

</template>


