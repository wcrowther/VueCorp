
<script setup>
	const newMessages = ref(3)
</script>

<template>
	
	<router-link v-if="newMessages > 0"  to="/accounts/messages"
		class="badge-button text-color-blue-gray bg-white hover:opacity-50"
		title="You have new Messages.">
		{{ newMessages }} {{ newMessages === 1 ? 'Message' : 'Messages'}}
	</router-link>  

</template>

<!-- USAGE -->

