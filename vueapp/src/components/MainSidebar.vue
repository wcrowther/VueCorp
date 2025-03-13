
<script setup>

    const appStore                  = useAppStore()
    const { sideBarHidden }         = storeToRefs(appStore)
    const { width: windowWidth }    = useWindowSize()

    const breakPoint = 500

    watch(() => windowWidth.value, (newVal, oldVal) => 
    { 
        if(newVal < breakPoint &&  oldVal >= breakPoint) 
            sideBarHidden.value = true
        else if (newVal >= breakPoint &&  oldVal < breakPoint)
            sideBarHidden.value = false
    });


</script>

<template>

    <!-- NOTE: 'v-show' NOT 'v-if' as we want to keep alive content and not have to recreate it  -->
    
    <div class="absolute z-50 xs:relative h-screen flex-none transform transition-all duration-[300ms] overflow-hidden"
        :class="[ sideBarHidden ? 'w-0' : 'w-full xs:w-[300px]']">
        <slot></slot> 
    </div>

</template>


<!-- 
    <div class="bg-red h-screen">FAKE CONTENT</div> 
-->
