
<script setup>
</script>

<template>

    <div class="flex flex-row h-screen" id="adminUsers">

        <SideBar class="transform transition-all duration-[500ms] h-full">
            <UsersList />
        </SideBar>     

        <DetailMain class="grow bg-gradient-main">
            <UsersDetail />
        </DetailMain>  

    </div> 

</template>