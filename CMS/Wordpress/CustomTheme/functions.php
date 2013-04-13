<?php 
	$sidebar_args = array( 'name'   => 'Main sidebar',
						   'id'     => 'sidebar_container',
						   'before_widget' => '<img class="paperclip" src="' . get_template_directory_uri() . '/images/paperclip.png" alt="paperclip" /><div class="sidebar">',
						   'after_widget'  => '</div>',);
	
	register_sidebar( $sidebar_args );
	
	register_nav_menus( array( 'Main nav' => 'Navigation Menu' ) );