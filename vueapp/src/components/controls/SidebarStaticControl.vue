<script setup></script>

<template>
	<div class="flex  relative overflow-hidden h-full">

		<div class="w-1/3 flex-1 flex">
			<slot name="sidebar"></slot><!-- sidebar content --> 
		</div>

		<div class="w-2/3 flex-1 flex">
            <slot></slot><!-- main content --> 
		</div>

	</div>
</template>


<!-- Usage: 

	<SidebarStaticControl>

		<template #sidebar>
			// Sidebar content here
		</template>

		// Main content here

	</SidebarStaticControl>	
-->