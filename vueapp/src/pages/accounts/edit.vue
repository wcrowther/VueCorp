<script setup>

    const isTop =  ref(false)

</script>

<template>
    <div class="p-5 border" id="accounts-edit">
        This is the Accounts Edit View
    </div>
    <div class="flex pl-5 gap-3">

        <IconSymbol class="transition-transform duration-500" :class="{'rotate-[-450deg]': isTop}"
            :color="isTop ? 'green': 'red'" @click="isTop=!isTop" width="96px" icon="mdi:arrow-down-thick" />

        <IconSymbol width="96px" :inline="false" :vertical-flip="true" 
            color="red" class="border border-red" icon="mdi:arrow-down-box" />

        <div class="bg-red contents h-fit w-fit">
            <IconSymbol class="" width="96px" icon="heroicons:academic-cap-16-solid" />
        </div> 
        
    </div>

</template>