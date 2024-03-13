<script setup>

    const props = defineProps({  show: Boolean })

</script>

<template>
    <Teleport to="body" v-if="props.show" >
        <div class="fixed left-2 bottom-3">
            <div class="capsule hidden xxs:block xs:hidden"  title="436px +" >xxs</div>
            <div class="capsule hidden  xs:block sm:hidden"  title="480px +" >xs</div>
            <div class="capsule hidden  sm:block md:hidden"  title="640px +" >sm</div>
            <div class="capsule hidden  md:block lg:hidden"  title="800px +" >md</div>
            <div class="capsule hidden  lg:block xl:hidden"  title="1024px +">lg</div>
            <div class="capsule hidden  xl:block 2xl:hidden" title="1280px +">xl</div>
            <div class="capsule hidden  2xl:block"           title="1536px +">2xl</div>
        </div>
    </Teleport>
</template>

<style lang="postcss" scoped>
    .capsule {
        @apply px-1.5 pt-[2px] pb-[3px] bg-[#f8ac59] text-red rounded-full text-center text-xs font-bold select-none 
    }
</style>
