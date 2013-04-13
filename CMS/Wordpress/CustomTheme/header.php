<!DOCTYPE HTML>
<html>

<head>
  <title><?php wp_title(); ?></title>
  <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
  <link rel="stylesheet" type="text/css" href="<?php echo bloginfo('stylesheet_url'); ?>" />
  <!-- modernizr enables HTML5 elements and feature detects -->
  <script type="text/javascript" src="<?php echo bloginfo('stylesheet_directory'); ?>/js/modernizr-1.5.min.js"></script>
</head>

<body>
  <div id="main">
    <header>
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_six", allows you to change the colour of the text -->
          <h1><a href="<?php echo home_url('/'); ?>"><?php echo bloginfo('name'); ?></a></h1>
          <h2><?php echo bloginfo('description'); ?></h2>
        </div>
      </div>
	  <?php 
		$nav_menu_args = array(
					'container'       => 'nav',
					'menu_class'      => 'sf-menu',
					'menu_id'         => 'nav',
					'echo'            => true,
					'fallback_cb'     => 'wp_page_menu',
					'items_wrap'      => '<ul id="%1$s" class="%2$s">%3$s</ul>',
					'depth'           => 0,
				);
	  
		wp_nav_menu($nav_menu_args); 
	  
	  ?>
    </header>