<script setup></script>

<template>

    <div class="-m-5 mb-5 p-3 flex flex-wrap justify-between 
        has-[>:only-child]:justify-start items-center
        bg-color-light-blue border-b border-color-blue-gray
        text-color-dark-blue font-bold whitespace-nowrap">
        <slot></slot>
    </div>

</template>

<!-- 
USE:  Wrap around Title forms to give added importance (Ex: see Account page title)
EXAMPLE: 

    <TitleBox>
       <span>{{account.AccountName}}</span>
       <span>Account Id: {{account.AccountId}}</span>    
    </TitleBox>
-->

