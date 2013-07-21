<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Albums</h1>
        <table bgcolor="#ccc">
          <tr bgcolor="#aaa">
            <th>Name</th>
            <th>Artist</th>
            <th>Year</th>
            <th>Producer</th>
            <th>Price</th>
            <th>Songs</th>
          </tr>

          <xsl:for-each select="/albums/album">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="year"/>
              </td>
              <td>
                <xsl:value-of select="producer"/>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
              <td>
                <table>
                  <tr>
                    <th>Title</th>
                    <th>Duration</th>
                  </tr>
                  <xsl:for-each select="./songs/song">
                   <tr>
                      <td>
                        <xsl:value-of select="title"/>
                      </td>
                      <td>
                        <xsl:value-of select="duration"/>
                      </td>
                   </tr>
                  </xsl:for-each>  
                </table>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>