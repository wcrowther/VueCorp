<script setup>

	const authStore			= useAuthStore()
	const { signup }		= authStore
	const userData 			= ref(new User())
	const v$ 				= useVuelidate(authSignupValidator, userData.value)

	const signupUser   		= () => signup(userData.value)

</script>

<template>

	<TextInput 		labelName="First Name" 	v-model="userData.FirstName" :v$ />
	<TextInput 		labelName="Last Name"  	v-model="userData.LastName"  :v$ />
	<TextInput 		labelName="User Email" 	v-model="userData.UserEmail" :v$ />
	<TextInput 		labelName="UserName" 	v-model="userData.UserName"  :v$ />
	<PasswordInput  labelName="Password" 	v-model="userData.Password"  :v$ />

	<div class="select-none pt-5 flex justify-end gap-3 mb-5">
		<button class="btn-primary" @click="signupUser">New User Sign Up</button>
		<slot></slot>
	</div>	

</template>






