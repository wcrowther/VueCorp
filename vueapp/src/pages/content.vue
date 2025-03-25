<script setup>

	const router = useRouter();
	router.replace('/content/main'); // Redirects to target route
	
</script>

<template>
	<LayoutMain>
		
		<SubNavBar />
		<router-view />

	</LayoutMain>
</template>
	