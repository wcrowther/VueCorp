<script setup>

	const toastStore  = useToastStore()

    const pageTitle  = ref('Admin Notes')

    const showFiveToasts = () => 
    {
        toastStore.showInfo('Showing five toasts...')   
        toastStore.showInfo('Showing five toasts...')   
        toastStore.showInfo('Showing five toasts...')
        toastStore.showInfo('Showing five toasts...')   
        toastStore.showInfo('Showing five toasts...')   
    }

</script>

<template>

    <div class="relative" id="adminNotes">

        <div class="z-0 bg-gradient-main h-[500px] absolute top-0 left-0 right-0"></div>

        <div class="relative p-5 pt-5 sm:p-10 sm:pt-5 pb-14">
            <div class="flex justify-between items-center mb-7 relative z-20">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ pageTitle }}</h2>
                <span class="flex flex-wrap gap-1.5">
                    <button @click="showFiveToasts" class="btn-primary" >Show Five Toasts</button>
                </span>
            </div>

            <HelpBox class="mb-5">
                The 'Show Five Toasts' button is to test that multiple identical toasts are not displayed
                if they are issued in a short sequence.
            </HelpBox>
            
            <div class="w-full min-h-[400px] relative z-20">
                <AdminNotes />  
            </div>
        </div>
	

    </div>  

</template>