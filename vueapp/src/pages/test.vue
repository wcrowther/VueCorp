<script setup>
	import PrimaryButton from '../components/buttons/PrimaryButton.vue';

    const appStore                  = useAppStore()
    const { sideBarHidden }         = storeToRefs(appStore)
</script>

<template>

	<div class="bg-gray h-12 p-3">
		<PrimaryButton @click="sideBarHidden = !sideBarHidden" title="Show / Hide" />
	</div>

    <SidebarControl :showSideBar="sideBarHidden">

        <template #sidebar>
            <div class="bg-orange w-full h-full p-5">sidebar</div>
        </template>

        <template #default>
            <div class="bg-yellow w-full h-full p-5">default</div>
        </template>

    </SidebarControl>	

</template>