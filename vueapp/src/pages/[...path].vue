<script setup>

	// =========================================================================================
	// NOTE: This file matches the [...path].vue which is the unplugin-vue-router catchall route
	// =========================================================================================

    const toastStore          = useToastStore()
    const authStore             = useAuthStore()
    const { delayedRedirect }   = authStore
    const redirectDelay         = 4000 
    const secondsDelay          = redirectDelay / 1000

    onMounted(() =>  
    {        
        delayedRedirect('/', redirectDelay ) 
        toastStore.showWarning(`Redirecting to Homepage in ${secondsDelay} seconds`)
    }); 

</script>

<template>  

    <LayoutMain>
        <div class="text-xl pt-20 font-bold text-center text-color-red ">
            Page Not Found
        </div>
    </LayoutMain>
    
</template>

<style></style>
