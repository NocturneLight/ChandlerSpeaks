import scrapy
import os

class GrantSpider(scrapy.Spider):
        name='grants'
        start_urls = ['https://www.grants.gov/rss/GG_NewOppByCategory.xml']

        def parse(self,response):
            GRANT_SELECTOR = 'item'
            for grants in response.css(GRANT_SELECTOR):

                TITLE_SELECTOR = 'title::text'
                LINK_SELECTOR = 'link::text'
                DESC_SELECTOR = 'description::text'     #shows <b>''</b>, don't know how to use XPath to remove it
                CAT_SELECTOR= 'category::text'
                yield{
                    'name': grants.css(TITLE_SELECTOR).extract_first(),
                    'link': grants.css(LINK_SELECTOR).extract_first(),
                    'description': grants.css(DESC_SELECTOR).extract_first(),
                    'category': grants.css(CAT_SELECTOR).extract_first()
                }
