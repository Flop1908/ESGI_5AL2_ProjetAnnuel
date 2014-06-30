//
//  AnneProduct.m
//  MultiProductViewer
//
//  Created by JN on 2014-3-18.
//  Copyright (c) 2014 thoughtbot, inc. All rights reserved.
//

#import "AnneProduct.h"

@implementation AnneProduct

+ (instancetype)productWithDictionary:(NSDictionary *)dict {
    AnneProduct *product = [[self alloc] init];
    //NSTimeInterval longueur= dict[@"Date"];
    //NSDate *dates = [NSDate dateWithTimeIntervalSince1970:*(NSTimeInterval)(dict[@"Date"])];
    if([dict[@"Type"] isEqual:@"VDM"]){
        product.author = dict[@"Author"];
        product.description = dict[@"Text"];
        product.nbcoms = dict[@"NbComments"];
        product.date= dict[@"Date"];
        product.votemoins = dict[@"Deserved"];
        product.voteplus = dict[@"Agree"];
        product.Id = dict[@"Id"];
        product.type = dict[@"Type"];
    }
    else if([dict[@"Type"] isEqual:@"DTC"]){
        product.author = dict[@"Author"];//ya pas
        product.description = dict[@"Text"];
        product.nbcoms = dict[@"NbComments"];
        product.date= dict[@"Date"];//ya pas
        product.votemoins = dict[@"Bad"];
        product.voteplus = dict[@"Good"];
        product.Id = dict[@"Id"];
        product.type = dict[@"Type"];
    }
    else if([dict[@"Type"] isEqual:@"CNF"]){
        product.author = dict[@"Author"];//ya pas
        product.description = dict[@"Text"];
        product.nbcoms = dict[@"NbComments"];
        product.date= dict[@"Date"];
        product.votemoins = dict[@"Bad"];//ya pas
        product.point = dict[@"Points"];
        product.Id = dict[@"Id"];
        product.type = dict[@"Type"];
    }
    else
    {
        NSLog(@"there is no ref of it");
    }
    /*if (dict[@"imageURL"]) {
        product.imageURL = dict[@"imageURL"];
    } else if (dict[@"imageURLString"]) {
        product.imageURL = [NSURL URLWithString:dict[@"imageURLString"]];
    }*/
    return product;
}

+ (NSArray *)productsWithArray:(NSArray *)array {
    NSMutableArray *products = [NSMutableArray arrayWithCapacity:[array count]];
    for (NSDictionary *dict in array) {
        AnneProduct *product = [self productWithDictionary:dict];
        [products addObject:product];
    }
    return products;
}

/*- (void)setProduct:(AnneProduct *)product {
    if (![product isEqual:_product]) {
        _product = product;
        self.textView.text = _product.description;
        self.author.text = _product.author;
        //self.dateLabel.text = _product.date;
        
    }
}*/
@end
