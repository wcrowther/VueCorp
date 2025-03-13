
<script setup>
</script>

<template>

    <div class="flex flex-row h-screen" id="adminUsers">

        <MainSidebar class="transform transition-all duration-[500ms] h-full">
            <UsersList />
        </MainSidebar>     

        <MainContent class="grow bg-gradient-main">
            <UsersDetail />
        </MainContent>  

    </div> 

</template>