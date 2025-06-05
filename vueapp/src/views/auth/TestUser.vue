<script setup>

	const userName 		= 'testuser'
	const password 		= 'Test123!'
	const modelValue 	= defineModel(new AuthRequest(userName, password))

	const setTestUser = () => 
	{
		modelValue.value.UserName = userName
		modelValue.value.Password = password
	}

</script>


<template>

	<div class="p-5 pb-7 flex flex-wrap bg-[#b8d7ed]/50">

		<div class="w-full mb-5">New users click
			<span class="italic font-bold">New User Signup</span> above or use the 
			<b>test login</b> below. 
		</div>

		<IconSymbol width="16px" class="text-color-dark-gray hover:text-black mr-3" 
			@click="setTestUser" icon="heroicons:arrow-top-right-on-square"/>

		<div class="flex-grow cursor-text" @click="setTestUser">
			<b>UserName:</b> testuser     
		</div>

		<div class="flex-grow text-end cursor-text" @click="setTestUser">
			<b>Password:</b> Test123!
		</div>

	</div>

</template>
