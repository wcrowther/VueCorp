
<script setup>

	import { useRouter }     from 'vue-router'

    // const appStore     	= useAppStore() 
    // const baseUrl       = appStore.baseUrl

	const router        = useRouter()
	const sitemap       = router
		.getRoutes() //.map(r => r.path)
		.filter(r => !r.path.includes(':')) // removes routes with params
		.map(r => `${r.path}`)
        .sort()

    console.log(`${sitemap.join('\n')}`)

</script>

<template>

    <div v-html="`${sitemap.join('<br/>')}`"></div>

</template>
	