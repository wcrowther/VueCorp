<script setup>

    const pageTitle  = ref('Account Notes')

</script>

<template>

    <div class="relative" id="adminNotes">

        <div class="z-0 bg-gradient-main h-[500px] absolute top-0 left-0 right-0"></div>

        <div class="p-5 pt-5 sm:p-10 sm:pt-5 pb-14">
            <div class="flex justify-between items-center mb-7 relative z-20">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ pageTitle }}</h2>
                <span class="flex flex-wrap gap-1.5">
                    <!-- <button class="custom-button" >Add</button>-->
                </span>
            </div>
            <div class="w-full min-h-[400px] relative z-20"></div>
        </div>

    </div>  

</template>


<!-- 
<div class="flex pl-5 gap-3">

    <IconSymbol class="transition-transform duration-500" :class="{'rotate-[-450deg]': isTop}"
        :color="isTop ? 'green': 'red'" @click="isTop=!isTop" width="96px" icon="mdi:arrow-down-thick" />

    <IconSymbol width="96px" :inline="false" :vertical-flip="true" 
        color="red" class="border border-red" icon="mdi:arrow-down-box" />

    <div class="bg-red contents h-fit w-fit">
        <IconSymbol class="" width="96px" icon="heroicons:academic-cap-16-solid" />
    </div> 
    
</div>
-->