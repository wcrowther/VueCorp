// eslint-disable-next-line vue/multi-word-component-names
<script setup>

</script>

<template>

    <div class="flex" id="adminUsers">

        <SideBar>
            <UsersList />
        </SideBar>     

        <DetailMain class="bg-gradient-main">
            <UsersDetail />
        </DetailMain>  

    </div> 

</template>