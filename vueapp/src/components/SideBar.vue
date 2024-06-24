
<script setup>

    const appStore                  = useAppStore()
    const { sideBarHidden }         = storeToRefs(appStore)
    const { width: windowWidth }    = useWindowSize()

    const breakPoint = 500

    watch(() => windowWidth.value, (newVal, oldVal) => 
    { 
        if(newVal < breakPoint && oldVal >= breakPoint)
        {
            sideBarHidden.value = true
        }
    });

</script>

<template>

    <!-- NOTE: 'v-show' NOT 'v-if' as we want to keep alive content and not have to recreate it  -->
    
    <div v-show="!sideBarHidden"
        class="absolute w-full xs:w-1/3 xs:relative h-full z-50">
        <slot></slot>
    </div>

</template>